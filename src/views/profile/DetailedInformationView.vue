<script setup>
import StatisticsView from './StatisticsView.vue';
</script>

<template>
    <el-tabs class="tabs" type="border-card">
        <el-tab-pane label="Statistics">
            <StatisticsView />
        </el-tab-pane>
        <el-tab-pane label="Games">Games</el-tab-pane>
    </el-tabs>
</template>

<style scoped>
.tabs {
    width: 70%;
}
</style>