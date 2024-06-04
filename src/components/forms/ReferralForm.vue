<script setup lang="ts">
import type { IAuthReferralForm } from '../../interfaces/auth/interfaces'

const props = defineProps<IAuthReferralForm>()
</script>

<template>
    <form @click.prevent class="referral_form">
        <div class="label">{{ props.label }}</div>
        <el-button @click="$emit('submit')"> {{ props.textButton }}</el-button>
    </form>
</template>

<style scoped></style>