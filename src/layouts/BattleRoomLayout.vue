<script setup>
import { onMounted } from 'vue';

onMounted(()=>{
    const editor = ace.edit("editor");
    console.log(editor);
    editor.setTheme("ace/theme/dracula");
    editor.session.setMode("ace/mode/golang");
    editor.setShowPrintMargin(false);
})
</script>

<template>
    <div class="container">

        <div class="task">Программа должна вывести на экран строку "Hello, World!" на языке программирования Go.</div>
        <div class="editor_container">
            <div id="editor"></div>
            <el-button plain type="warning"> Проверить </el-button>
        </div>
    </div>
</template>

<style scoped>
    .editor_container{
        position: relative;
        width: 60%;
        height: 500px;
    }

    #editor{
        width: 100%;
        height: 90vh; 
    }

    .container{
        display: flex;
        justify-content: space-between;
    }
</style>