<script setup lang="ts">
import { computed, ref, watchEffect } from 'vue';

const props = defineProps({
    mouseEvent: {
        required: false,
        type: MouseEvent
    }
})

const m = computed(() => props.mouseEvent)
const activeTabIndex = ref<number>()

watchEffect(() => {
    console.log(m.value);

})
</script>

<template>
    <header>
        <ul>
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
    width: 80%;
    margin: 0 auto;
    background-color: rgb(80, 11, 73);
    height: 60px;
    display: flex;
    justify-content: space-around;
    align-items: center;

    box-shadow: 12px 0px 500px 0px rgb(80, 11, 73, 0.5);
}
</style>