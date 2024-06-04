<script setup>
import {ref} from 'vue'
const gamesPlayed = ref(11)
const eloRating = ref(2400)
</script>

<template>
    <div>
        <ul>
            <li>Кол-во игр: {{ gamesPlayed }}</li>
            <li>ELO: {{ eloRating }}</li>
        </ul>
    </div>
</template>

<style scoped>
    ul{
        display: flex;
        justify-content: space-around;
    }
</style>