<template>
    <div></div>
</template>

<script lang="ts">
    import { Vue, Component } from 'vue-property-decorator';
    import { Context, EnableProp, RouteName } from 'ea-router';
    import { FavoriteLink } from '@/domain/views';

    @RouteName(FavoriteLink)
    @Context('id')
    @EnableProp()
    @Component
    export default class FavoriteLinkPage extends Vue {}
</script>
