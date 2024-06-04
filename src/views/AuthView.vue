<script setup lang="ts">
import AuthCard from '@/components/forms/AuthCard.vue';
import { AuthTypes } from '@/interfaces/auth/enums';
import type { AuthCardType } from '@/interfaces/auth/types';
import { computed, ref } from 'vue';
import ReferralForm from '@/components/forms/ReferralForm.vue'
import ServerResponseForm from '@/components/forms/ServerResponseForm.vue'

const type = ref<AuthCardType>(AuthTypes.login)
const textButtonRefferal = computed(() => type.value === 'login' ? "Go to register" : 'Go to login')
const label = computed(() => type.value === 'login' ? 'Еще не зарегистрировались ?' : 'Есть учетная запись')

const formSubmitted = ref(false)
const positionRight = computed(() => type.value === 'login' ? '60%' : '7%')

const response = ref<any>(undefined)

function changeAuthCard() {
    if (type.value === AuthTypes.login)
        type.value = AuthTypes.password
    else
        type.value = AuthTypes.login
}

async function auth() {
    formSubmitted.value = true
    const req = await new Promise((res) => setTimeout(res, 2000))

    response.value = 'ответ'
}
</script>

<template>
    <div class="auth_form">
        <Transition name="flightCard">
            <AuthCard v-if="!formSubmitted" @submit="auth" :type="type" :rightPosition="positionRight" />
        </Transition>
        <div :style="{ 'float': type === 'password' ? 'left' : 'right' }" class="second_form">
            <ServerResponseForm @submit="formSubmitted = false" v-if="formSubmitted" />
            <ReferralForm v-else :label="label" :textButton="textButtonRefferal" @submit="changeAuthCard" />
        </div>
    </div>
</template>

<style scoped>
.response {
    float: right;
}

.auth_form {
    background-color: rgba(34, 34, 34, 0.3);
    width: 50%;
    min-width: 350px;
    height: 250px;

    border-bottom-right-radius: 10px;

    backdrop-filter: blur(20px);

    box-shadow: inset 0px 0px 20px 0px rgba(146, 146, 146, 0.5);
}

.second_form {
    width: 50%;
    height: 100%;
    display: flex;
}

.referral_form{
    margin: 0 auto;
    align-self: center;
}
</style>
