import { HttpErrorHandler } from '.';
import { Loader } from 'vuetify-extension';

export default class AxiosHttpErrorHandler implements HttpErrorHandler {
  process(error: any): void {
    Loader.CloseAll();
  }
}
