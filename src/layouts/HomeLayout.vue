<script setup lang="ts">
import HeaderView from '@/views/HeaderView.vue'
import FooterView from '@/views/FooterView.vue'
import { ref, shallowRef } from 'vue';
import { throttle } from '@/helpers/throttle'

const mouseEvent = ref<MouseEvent>()
const throttleUpdateMouseEvent = throttle(updateMouseEvent,100)

const activeView = shallowRef()

function updateMouseEvent(event:MouseEvent){
    mouseEvent.value = event
}

function replaceActiveTab(component:any){
    activeView.value = component
}
</script>

<template>
    <div class="container" @mousemove="throttleUpdateMouseEvent">
        <HeaderView :onSwitch-view="replaceActiveTab" :mouseEvent = "mouseEvent"/>
        <div style="padding-top: 100px;">
            <component :is="activeView"/>
        </div>
        <FooterView/>
    </div>
</template>

<style>
    .container{
        height: 100%;
    }
</style>