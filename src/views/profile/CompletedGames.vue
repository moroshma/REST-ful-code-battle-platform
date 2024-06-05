<script setup>
const tableData = [
    {
        status: 'lost',
        lang: 'Go',
        enemy: 'JDM',
        date: '02.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    },
    {
        status: 'win',
        lang: 'Go',
        enemy: 'Roma',
        date: '01.06.2024'
    }
]

const handleClick = (event) => {
    console.log(event, 'click')
}
</script>

<template>
    <el-table :data="tableData" style="width: 100%">
        <el-table-column fixed prop="date" label="Date" />
        <el-table-column prop="status" label="Status" />
        <el-table-column prop="lang" label="Language" />
        <el-table-column prop="enemy" label="Enemy" />
        <el-table-column fixed="right" label="Detail">
            <template #default>
                <el-button link type="primary" size="small" @click="handleClick">
                    Detail
                </el-button>
            </template>
        </el-table-column>
    </el-table>
</template>

<style scoped>
ul {
    display: flex;
    flex-direction: column;
}

li {
    margin-right: 10%
}
</style>