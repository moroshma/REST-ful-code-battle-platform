<script setup lang="ts">
import type { IAuthReferralForm } from '../../interfaces/auth/interfaces'

const props = defineProps<IAuthReferralForm>()
</script>

<template>
    <form @click.prevent style="display: block;" class="referral_form">
        <div class="label">{{ props.label }}</div>
        <button @click="$emit('submit')">{{ props.textButton }}</button>
    </form>
</template>

<style scoped></style>