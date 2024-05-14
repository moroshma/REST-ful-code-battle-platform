<script setup lang="ts">
import AuthView from '@/views/AuthView.vue';
import backGround from '../assets/videos/code.mp4'
</script>

<template>
    <div class="auth_container">
        <video autoplay loop muted="true" :src="backGround"></video>
        <div class="auth_container__form">
            <AuthView />
        </div> 
    </div>

</template>

<style scoped>
video {
    position: fixed;
    height: 100%;
    width: 100%;
    opacity: 0.07;
    top: 0;
    left: 0;
    -o-object-fit: cover;
      object-fit: cover;
}

.auth_container {
    position: relative;
    overflow: hidden;
    height: 100%;
    display: flex;
    flex-direction: column;
    justify-content: center;
}

.auth_container__form {
    display: flex;
    justify-content: center;
}
</style>