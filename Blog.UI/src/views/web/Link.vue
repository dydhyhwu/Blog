<template>
    <div>
        {{ link.title }}
        <br />
        {{ link.description }}
        <br />
        {{ link.content }}
        <br />
    </div>
</template>

<script lang="ts">
    import { Component, Prop } from 'vue-property-decorator';
    import { Context, EnableProp, RouteName } from 'ea-router';
    import { FavoriteLinkInfo } from '@/domain/views';
    import { FavoriteLink } from '@/models/FavoriteLink';
    import BasePage from '../../infrastructure/basePage';

    @RouteName(FavoriteLinkInfo)
    @Context('id')
    @EnableProp()
    @Component
    export default class FavoriteLinkPage extends BasePage {
        @Prop() id: string;

        link: FavoriteLink = null;

        mounted() {
            this.getLink();
        }

        async getLink() {
            this.link = await this.repository.FavoriteLink.get(this.id);
        }
    }
</script>
