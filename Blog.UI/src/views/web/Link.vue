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
    import { Vue, Component, Inject, Prop } from 'vue-property-decorator';
    import { Context, EnableProp, RouteName } from 'ea-router';
    import { FavoriteLinkInfo } from '@/domain/views';
    import { FavoriteLink } from '@/models/FavoriteLink';
    import { Repository } from '@/domain/providers';
    import { Repositories } from '@/infrastructure/repository';

    @RouteName(FavoriteLinkInfo)
    @Context('id')
    @EnableProp()
    @Component
    export default class FavoriteLinkPage extends Vue {
        @Prop() id: string;

        link: FavoriteLink = null;

        @Inject(Repository) repository: Repositories;

        mounted() {
            this.getLink();
        }

        async getLink() {
            this.link = await this.repository.FavoriteLink.get(this.id);
        }
    }
</script>
