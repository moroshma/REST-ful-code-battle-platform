<script setup>
import StatisticsView from './StatisticsView.vue';
import CompletedGames from './CompletedGames.vue';
</script>

<template>
    <el-tabs class="tabs" type="border-card">
        <el-tab-pane label="Statistics">
            <StatisticsView />
        </el-tab-pane>
        <el-tab-pane style="overflow: auto; max-height: 700px" label="Completed games"><CompletedGames/></el-tab-pane>
    </el-tabs>
</template>

<style scoped>
.tabs {
    width: 70%;
}
</style>