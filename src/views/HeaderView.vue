<script setup lang="ts">
import { computed, ref, watchEffect } from 'vue';
import type { IBoxShadow, IMouseCoords } from '@/interfaces/homePage/interfaces'

const props = defineProps({
    mouseEvent: {
        required: false,
        type: MouseEvent
    }
})

const boxShadowStyle = ref('12px 0px 500px 5px rgb(80, 11, 73, 1)')

const mouseEvent = computed(() => props.mouseEvent)
const activeTabIndex = ref<number>()

watchEffect(() => {
    const coords = getMouseCoordsRelativeToTheCenter(mouseEvent.value)

    setBoxShadowStyle(getBoxShadowStyle(coords))
})

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
    const ratio = (mouseCoords.y / document.body.clientHeight) * 600
    return { ...mouseCoords,y:ratio, opacity: 0.8, blur: 500 }
}

function setBoxShadowStyle(obj: IBoxShadow): void {
    const { x, y, blur, opacity } = obj
    boxShadowStyle.value = `${x / 7}px ${y / 7}px ${blur}px 40px rgb(80, 11, 73, ${opacity})`
}
</script>

<template>
    <header>
        <ul :style="{ 'box-shadow': boxShadowStyle }">
            <li> <el-button type="danger" :round="activeTabIndex === 1" @click="activeTabIndex = 1">Battles</el-button>
            </li>
            <li> <el-button type="primary" :round="activeTabIndex === 2" @click="activeTabIndex = 2">Profile</el-button>
            </li>
            <!-- тот кто смотрит не переживай, здесь будет рендер в цикле :) -->
        </ul>
    </header>
</template>

<style scoped>
header {
    margin-top: 1%;
    position: fixed;
    width: 100%;
}

header ul {
    transition: all 0.1s;
    width: 50%;
    margin: 0 auto;
    background-color: rgb(75, 25, 70);
    height: 60px;
    display: flex;
    justify-content: space-around;
    align-items: center;


    border-radius: 5px;
}
</style>