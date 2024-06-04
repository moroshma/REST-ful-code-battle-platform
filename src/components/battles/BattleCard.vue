<script setup lang="ts">

</script>

<template>
    <div class="battle_card">
        <div class="battle_card_container">
            <div class="battle_card__title">
                Стандартный режим сражений
            </div>

            <div class="battle_card__description">
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quasi cumque harum deserunt, voluptatum
                molestiae quae labore autem, excepturi fuga aspernatur cupiditate vitae! Nihil voluptatibus a similique
                in veniam voluptates.
            </div>
            <el-button> Battle</el-button>
        </div>
    </div>
</template>

<style scoped>
.battle_card {
    color: aliceblue;
    background-color: var(--general-style);
    width: 30%;
    margin: 3%;
   
}

.battle_card_container{
    display: flex;
    flex-direction: column;
    padding: 10px;
}

.battle_card__title {
    font-weight: bold;
    padding-bottom: 10px;
}

button {
    margin: 10px;
    align-self: center;
}
</style>