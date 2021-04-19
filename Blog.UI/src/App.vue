<template>
    <v-app>
        <router-view></router-view>
    </v-app>
</template>

<script lang="ts">
    import { Vue, Component, Provide } from 'vue-property-decorator';
    import { Navigator, Repository } from '@/domain/providers';
    import RepositoryImpl, { Repositories } from '@/infrastructure/repository';
    import SimpleNavigation, { Navigation } from '@/infrastructure/navigator';

    @Component
    export default class AppEntry extends Vue {
        @Provide(Repository) repository: Repositories = new RepositoryImpl();
        @Provide(Navigator) navigator: Navigation = SimpleNavigation.Instance;
    }
</script>
