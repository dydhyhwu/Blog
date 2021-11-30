import { HttpErrorHandler } from '.';
import { SimpleLoadingOperator } from '@dydhyh/ui-tools';

export default class AxiosHttpErrorHandler implements HttpErrorHandler {
    process(error: any): void {
        SimpleLoadingOperator.Instance.closeAll();
    }
}
