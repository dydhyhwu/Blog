import AxiosHttpResponseHandler from "@/infrastructure/http/HttpResponseHandler";
import AxiosHttpRequestFilter from "@/infrastructure/http/HttpRequestFilter";
import AxiosHttpErrorHandler from "@/infrastructure/http/HttpErrorHandler";
import AxiosHttp from "@/infrastructure/http";
import config from "@/config";

export default class Startup {
  static init() : void {
    Startup.configurationHttp();
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
}