<script setup lang="ts">
import { computed, ref, shallowRef, watchEffect } from 'vue';
import type { IBoxShadow, IMouseCoords } from '@/interfaces/homePage/interfaces'
import BattlesView from '@/views/BattlesView.vue'
import ProfileView from '@/views/ProfileView.vue'

const emit = defineEmits(['switch-view', 'log-out'])

const props = defineProps({
    mouseEvent: {
        required: false,
        type: MouseEvent
    }
})

const boxShadowStyle = ref('12px 0px 500px 5px rgb(80, 11, 73, 1)')

const mouseEvent = computed(() => props.mouseEvent)
const activeTabIndex = ref<number>(0)

const headerButtons = ref([
    {
        text: 'Battles',
        type: 'danger',
        component: shallowRef(BattlesView)
    },
    {
        text: 'Profile',
        type: 'primary',
        component: shallowRef(ProfileView)
    },
])

watchEffect(() => {
    const coords = getMouseCoordsRelativeToTheCenter(mouseEvent.value)

    setBoxShadowStyle(getBoxShadowStyle(coords))
})

watchEffect(() => {
    replaceActiveTab(activeTabIndex.value)
})

function replaceActiveTab(index: number) {
    activeTabIndex.value = index
    emit('switch-view', headerButtons.value[index].component)

}

function getMouseCoordsRelativeToTheCenter(mouseEvent: MouseEvent | undefined): IMouseCoords {
    if (!mouseEvent) return {
        x: 0,
        y: 0,
    }
    const width = window.document.body.clientWidth
    const height = window.document.body.clientHeight

    const centerX = width / 2
    const centerY = height / 2

    const x = mouseEvent.x - centerX
    const y = mouseEvent.y - centerY
    return {
        x,
        y,
    }
}

function getBoxShadowStyle(mouseCoords: IMouseCoords): IBoxShadow {
    const ratio = (mouseCoords.y / document.body.clientHeight) * 700
    return { ...mouseCoords, y: ratio, opacity: 0.9, blur: 600 }
}

function setBoxShadowStyle(obj: IBoxShadow): void {
    const { x, y, blur, opacity } = obj
    const ratio = 7
    boxShadowStyle.value = ` ${x / ratio}px ${y / ratio}px ${blur}px 60px rgb(80, 30, 120, ${opacity})`
}

function logOut(){
    console.log('out');
    
    emit('log-out')
}
</script>

<template>
    <header>
        <nav :style="{ 'box-shadow': boxShadowStyle }">
            <ul>
                <li v-for="(button, index) in headerButtons" :key="button.type + button.text">
                    <el-button :type="button.type" :round="activeTabIndex === index" @click="replaceActiveTab(index)">
                        {{ button.text }}
                    </el-button>
                </li>
            </ul>
            <ul>
                <el-button type="warning" @click="logOut">
                    Log out
                </el-button>
            </ul>
        </nav>

    </header>
</template>

<style scoped>
header {
    margin-top: 1%;
    position: fixed;
    width: 100%;
}

header nav {
    transition: box-shadow 0.1s;
    width: 50%;
    margin: 0 auto;
    display: flex;
    height: 60px;
    background-color: var(--general-style);
}

header ul {

    width: 100%;
    display: flex;
    justify-content: space-around;
    align-items: center;


    border-radius: 5px;
}
</style>