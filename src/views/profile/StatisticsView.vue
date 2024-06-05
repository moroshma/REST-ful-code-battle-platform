<script setup>
import {ref} from 'vue'
const gamesPlayed = ref(11)
const eloRating = ref(2400)
</script>

<template>
    <div>
        <ul>
            <li> <span class="statistic">{{ gamesPlayed }}</span> <br> Кол-во игр</li>
            <li> <span class="statistic">{{ eloRating }}</span> <br> ELO</li>
        </ul>
    </div>
</template>

<style scoped>
    ul{
        display: flex;
        justify-content: space-around;
    }

    ul li{
        text-align: center;
    }

    .statistic{
        font-weight: bold;
        font-size: 24px;
    }
</style>