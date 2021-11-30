import { HttpResponseHandler } from '.';
import { AxiosResponse } from 'axios';
import { SimpleLoadingOperator, SimpleMessageOperator } from '@dydhyh/ui-tools';
import HttpResponse, {
    ResponseStatus,
} from '@/infrastructure/http/HttpResponse';

export default class AxiosHttpResponseHandler implements HttpResponseHandler {
    getResult<T = any>(response: AxiosResponse): T {
        return response.data.data as T;
    }

    isSuccess(response: AxiosResponse | void): boolean {
        if (!response) return false;
        return response.data.code === 200;
    }

    async process(
        response: AxiosResponse | void,
        ignoreBusinessException: boolean,
        reject: (error: any) => void
    ): Promise<void> {
        SimpleLoadingOperator.Instance.closeAll();

        if (!response) return;
        const data = response.data as HttpResponse;
        if (!data) return;
        if (ignoreBusinessException) {
            reject(data.message);
        }

        switch (data.code) {
            case ResponseStatus.noAuthorize:
                SimpleMessageOperator.Instance.error('请登录后再进行操作.');
                break;
            case ResponseStatus.authorizeExpired:
                SimpleMessageOperator.Instance.error('登录过期，请重新登录.');
                break;
            case ResponseStatus.noPermission:
                SimpleMessageOperator.Instance.error('暂无权限.');
                break;
            default:
                SimpleMessageOperator.Instance.error(data.message);
                break;
        }
    }
}
