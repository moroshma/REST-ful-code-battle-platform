<script setup lang="ts">
import HeaderView from '@/views/HeaderView.vue'
import FooterView from '@/views/FooterView.vue'
import { ref } from 'vue';
import { throttle } from '@/helpers/throttle'

const mouseEvent = ref<MouseEvent>()

const throttleUpdateMouseEvent = throttle(updateMouseEvent,200)

function updateMouseEvent(event:MouseEvent){
    mouseEvent.value = event
}
</script>

<template>
    <div class="container" @mousemove="throttleUpdateMouseEvent">
        <HeaderView :mouseEvent = "mouseEvent"/>
        body
        <FooterView/>
    </div>
</template>

<style>
    .container{
        height: 100%;
    }
</style>