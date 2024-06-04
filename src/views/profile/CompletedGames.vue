<script setup>
const games = ref([
    {
        status:'lost',
        lang:'Go',
        enemy:'JDM',
        date:'02.06.2024'
    },
    {
        status:'win',
        lang:'Go',
        enemy:'Roma',
        date:'01.06.2024'
    }
])
</script>

<template>
    <div v-for="game in games" :key="game.date">
        <ul>
            <li>{{ game.status }}</li>
            <li>{{ game.lang }}</li>
            <li>{{ game.enemy }}</li>
            <li>{{ game.date }}</li>
        </ul>
    </div>
</template>

<style>

</style>