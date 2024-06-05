<script setup>
import { VAceEditor } from 'vue3-ace-editor';
import ace from 'ace-builds';
import modeGoUrl from 'ace-builds/src-noconflict/mode-golang?url';
import themeDraculaUrl from 'ace-builds/src-noconflict/theme-dracula?url';
import {onMounted,ref} from 'vue'

const aceRef = ref(null);
ace.config.setModuleUrl('ace/theme/dracula', themeDraculaUrl);
ace.config.setModuleUrl('ace/mode/golang', modeGoUrl);
onMounted(() => {
        console.log(aceRef.value.getAceInstance());
        aceRef.value.getAceInstance().setFontSize(20)
   })
</script>

<template>
    <div class="container">

        <div class="task">Программа должна вывести на экран строку "Hello, World!" на языке программирования Go.</div>
        <div class="editor_container">
            <v-ace-editor ref="aceRef" :print-margin="false" v-model:value="content" @init="editorInit" lang="golang" theme="dracula"
                style="height: 90vh" :options="{ useWorker: true }"/>
            <el-button plain type="warning"> Проверить </el-button>
        </div>
    </div>
</template>

<style scoped>
.editor_container {
    position: relative;
    width: 60%;
    height: 500px;
}

.container {
    display: flex;
    justify-content: space-between;
}
</style>