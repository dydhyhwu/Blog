<template>
    <mavon-editor v-model="content"></mavon-editor>
</template>

<script lang="ts">
    import { Vue, Component, VModel } from 'vue-property-decorator';
    import 'mavon-editor/dist/css/index.css';

    @Component
    export default class Mavon extends Vue {
        @VModel({ type: String, default: '' }) content: string;
    }
</script>
