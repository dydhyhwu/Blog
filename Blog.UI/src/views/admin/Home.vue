<template>
    <div>123</div>
</template>

<script lang="ts">
    import { Vue, Component } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { AdminHome } from '@/domain/views';

    @RouteName(AdminHome)
    @Component
    export default class AdminHomePage extends Vue {}
</script>
