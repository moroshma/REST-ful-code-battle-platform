<script setup lang="ts">
import type { IAuthCardProps } from '@/interfaces/auth/interfaces';
import { ref } from 'vue';

const props = defineProps<IAuthCardProps>()
const emit = defineEmits(['submit'])

const formValues = ref({
    type: props.type,
    email: '',
    password: ''
})

function submit() {
    emit('submit', formValues)
}
</script>

<template>
    <div class="auth_card" :style="{ 'left': leftPositionCard }">
        <form @submit.prevent="submit">
            <Transition name="replacingInputFields">
                <div v-if="props.type === 'login'" style="display: flex; flex-direction: column;">
                    <input v-model="formValues.email" type="email">
                    <input v-model="formValues.password" type="password">

                    <button>log</button>
                </div>
                <div v-else style="display: flex; flex-direction: column;">
                    <input v-model="formValues.email" type="email">
                    <input v-model="formValues.password" type="password">
                    <input v-model="formValues.password" type="password">

                    <button>Register</button>
                </div>
            </Transition>
        </form>
    </div>
</template>

<style scoped>
form {
    text-align: center;
    align-self: center;
}

.auth_card {
    display: flex;
    justify-content: center;
    overflow: hidden;
    position: absolute;
    height: 120%;
    left: 53%;
    background-color: #101d1d;
    width: 300px;
    top: -10%;

    opacity: 1;
    transition: all 0.5s;

    border-bottom-right-radius: 10%;
    border-bottom-left-radius: 10%;
}

.auth_card input {
    margin-bottom: 5px;
}
</style>