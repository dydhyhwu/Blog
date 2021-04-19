import VueRouter from 'vue-router';

export interface Navigation {
    redirect(name: string, context?: any, query?: any): void;

    replace(name: string, query?: any): void;

    resolve(name: string, query?: any): any;

    resolveUrl(name: string, query?: any): string;

    back(): void;

    existed(name: string, query: any, context: any): boolean;

    getRoute(name: string, query?: any, context?: any): any;

    isCurrentRoute(location: any): boolean;
}

export default class SimpleNavigation implements Navigation {
    private router: VueRouter;
    private static _instance: Navigation;

    constructor(router: VueRouter) {
        this.router = router;
    }

    static get Instance(): Navigation {
        return SimpleNavigation._instance;
    }

    static Init(router: VueRouter) {
        SimpleNavigation._instance = new SimpleNavigation(router);
    }

    redirect(name: string, context?: any, query?: any): void {
        const location = this.getRoute(name, query, context);
        if (this.isCurrentRoute(location)) {
            return;
        }
        this.router.push(location);
    }

    replace(name: string, query: any) {
        const location = this.getRoute(name, query);
        this.router.replace(location);
    }

    resolve(name: string, query: any) {
        const location = this.getRoute(name, query);
        return this.router.resolve(location);
    }

    resolveUrl(name: string, query: any): string {
        return `${window.location.origin}${this.resolve(name, query).href}`;
    }

    back(): void {
        this.router.back();
    }

    existed(name: string, query: any, context: any): boolean {
        const matched = this.router.getMatchedComponents({
            name: name,
            query: query,
            params: context,
        });
        return matched.length > 0;
    }

    getRoute(name: string, query?: any, context?: any): any {
        const route = {
            name: name,
            query: query ?? {},
            params: context ?? {},
        };
        const routeIsExisted = this.existed(name, query, context);
        if (!routeIsExisted) {
            return '/404';
        }
        return route;
    }

    isCurrentRoute(location: any): boolean {
        const currentRoute = this.router.currentRoute;
        return currentRoute.name === location.name;
    }
}
