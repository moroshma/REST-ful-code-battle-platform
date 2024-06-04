<script setup > 
import DetailedInformationView from './DetailedInformationView.vue'
import UserCardView from './UserCardView.vue'
</script>

<template>
    <div class="user_info">
        <UserCardView/>

        <DetailedInformationView/>
    </div>
</template>

<style>
    .avatar{
        width: 200px;
    }

    .user_info{
        justify-content: space-around;
        display: flex
    }
</style>