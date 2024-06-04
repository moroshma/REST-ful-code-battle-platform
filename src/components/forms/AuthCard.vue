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
    <div class="auth_card" :style="{ 'right': props.rightPosition }">
        <form @submit.prevent="submit">
            <Transition name="replacingInputFields">
                <div v-if="props.type === 'login'" style="display: flex; flex-direction: column;">
                    <el-input v-model="formValues.email" style="width: 240px" placeholder="Please input Email" />
                    <el-input v-model="formValues.password" style="width: 240px" type="password"
                        placeholder="Please input password" show-password />

                    <el-button type="plain" @click="submit">
                        Login
                    </el-button>
                </div>
                <div v-else style="display: flex; flex-direction: column;">
                    <el-input v-model="formValues.email" style="width: 240px" placeholder="Please input Email" />
                    <el-input v-model="formValues.password" style="width: 240px" type="password"
                        placeholder="Please input password" show-password />
                    <el-input style="width: 240px" type="password"
                        placeholder="Please input password" show-password />

                    <el-button type="plain" @click="submit">
                        Register
                    </el-button>
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

form div>* {
    margin-bottom: 3px;
}

form .el-input__inner {
    margin-bottom: 5px
}

.auth_card {
    display: flex;
    justify-content: center;
    position: absolute;
    height: 120%;
    width: 300px;
    top: -10%;
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