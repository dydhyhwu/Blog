import AxiosHttpResponseHandler from '@/infrastructure/http/HttpResponseHandler';
import AxiosHttpRequestFilter from '@/infrastructure/http/HttpRequestFilter';
import AxiosHttpErrorHandler from '@/infrastructure/http/HttpErrorHandler';
import AxiosHttp from '@/infrastructure/http';
import config from '@/config';
import SimpleNavigation from '@/infrastructure/navigator';
import router from '@/router';
import Vue from 'vue';
import MavonEditor from 'mavon-editor';
import '@/assets/style/common.css';
import UITools from '@dydhyh/ui-tools';
import VuetifyTools from '@dydhyh/vuetify-tools';
import Vuetify from '../plugins/vuetify';

export default class Startup {
    static init(): void {
        Startup.configurationComponent();
        Startup.configurationHttp();
        Startup.configurationRouter();
    }

    private static configurationHttp() {
        const responseHandler = new AxiosHttpResponseHandler();
        const requestFilter = new AxiosHttpRequestFilter();
        const errorHandler = new AxiosHttpErrorHandler();
        AxiosHttp.Instance.setConfig(config)
            .setResponseHandler(responseHandler)
            .setRequestFilter(requestFilter)
            .setSystemErrorHandler(errorHandler);
    }

    private static configurationRouter() {
        SimpleNavigation.Init(router);
    }

    private static configurationComponent() {
        Vue.use(MavonEditor);
        Vue.use(UITools, {
            deps: { vuetify: Vuetify },
            components: VuetifyTools,
        });
    }
}
