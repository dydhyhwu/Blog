<template>
    <div>provider</div>
</template>

<script lang="ts">
    import { Component } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { CloudProviderManage } from '@/domain/views';
    import BasePage from '@/infrastructure/basePage';

    @RouteName(CloudProviderManage)
    @Component
    export default class CloudProviderManagePage extends BasePage {}
</script>
