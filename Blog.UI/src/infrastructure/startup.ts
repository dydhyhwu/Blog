import AxiosHttpResponseHandler from '@/infrastructure/http/HttpResponseHandler';
import AxiosHttpRequestFilter from '@/infrastructure/http/HttpRequestFilter';
import AxiosHttpErrorHandler from '@/infrastructure/http/HttpErrorHandler';
import AxiosHttp from '@/infrastructure/http';
import config from '@/config';
import SimpleNavigation from '@/infrastructure/navigator';
import router from '@/router';

export default class Startup {
    static init(): void {
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
}
