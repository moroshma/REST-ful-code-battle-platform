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
    <div class="auth_card" :style="{'right': props.rightPosition}">
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
    position: absolute;
    height: 100%;
    width: 300px;
    top: 0%;
    opacity: 1;
    transition: all 0.5s;

    border: 50px solid transparent;
    border-top: 70px solid #101d1d;

    border-bottom: 70px solid #101d1d;

}

.auth_card input {
    margin-bottom: 5px;
}
</style>