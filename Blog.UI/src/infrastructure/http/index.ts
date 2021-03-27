import axios, { AxiosRequestConfig, AxiosResponse } from "axios";

export interface HttpConfig {
  Host: string;
}

export interface HttpRequestFilter {
  process(config: AxiosRequestConfig): AxiosRequestConfig;
}

export interface HttpResponseHandler {
  isSuccess(response: AxiosResponse | void): boolean;
  getResult<T = any>(response: AxiosResponse): T;

  process(
    response: AxiosResponse | void,
    ignoreBusinessException: boolean,
    reject: (error: any) => void
  ): Promise<void>;
}

export interface HttpErrorHandler {
  process(error: any): void;
}

export interface Http {
  setConfig(config: HttpConfig): Http;
  setResponseHandler(handler: HttpResponseHandler): Http;
  setRequestFilter(filter: HttpRequestFilter): Http;
  setSystemErrorHandler(handler: HttpErrorHandler): Http;
  get<T>(url: string, params?: object, timeout?: number): Promise<T>;
  getWithoutCatch<T>(
    url: string,
    params?: object,
    timeout?: number
  ): Promise<T>;
  post<T>(url: string, data: object, timeout?: number): Promise<T>;
  postWithoutCatch<T>(url: string, data: object, timeout?: number): Promise<T>;
}

class AxiosHttp implements Http {
  private static instance: Http = new AxiosHttp();
  private config: HttpConfig;
  private filter?: HttpRequestFilter;
  private responseHandler: HttpResponseHandler;
  private httpErrorHandler?: HttpErrorHandler;

  protected constructor() {}

  static get Instance() {
    return this.instance;
  }

  get<T>(url: string, params?: object, timeout?: number): Promise<T> {
    const requestConfig: AxiosRequestConfig = {
      url: this.getUrl(url),
      params: params,
      timeout: timeout,
    };
    return this.sendHttpRequest<T>(requestConfig);
  }

  getWithoutCatch<T>(
    url: string,
    params?: object,
    timeout?: number
  ): Promise<T> {
    const requestConfig: AxiosRequestConfig = {
      url: this.getUrl(url),
      params: params,
      timeout: timeout,
    };
    return this.sendHttpRequest<T>(requestConfig, true);
  }

  post<T>(url: string, data: object, timeout?: number): Promise<T> {
    const requestConfig: AxiosRequestConfig = {
      method: "post",
      url: this.getUrl(url),
      data: data,
      timeout: timeout,
    };

    return this.sendHttpRequest<T>(requestConfig);
  }

  postWithoutCatch<T>(url: string, data: object, timeout?: number): Promise<T> {
    const requestConfig: AxiosRequestConfig = {
      method: "post",
      url: this.getUrl(url),
      data: data,
      timeout: timeout,
    };

    return this.sendHttpRequest<T>(requestConfig, true);
  }

  setRequestFilter(filter: HttpRequestFilter): Http {
    this.filter = filter;
    return this;
  }

  setSystemErrorHandler(handler: HttpErrorHandler): Http {
    this.httpErrorHandler = handler;
    return this;
  }

  setConfig(config: HttpConfig): Http {
    this.config = config;
    return this;
  }

  setResponseHandler(handler: HttpResponseHandler): Http {
    this.responseHandler = handler;
    return this;
  }

  private filterRequest(config: AxiosRequestConfig): AxiosRequestConfig {
    if (this.filter) {
      config = this.filter.process(config);
    }

    config.timeout = config.timeout ? config.timeout : 30000;
    return config;
  }

  private getUrl(url: string) {
    return this.config.Host + url;
  }

  private sendHttpRequest<T>(
    config: AxiosRequestConfig,
    ignoreBusinessException = false
  ): Promise<T> {
    config = this.filterRequest(config);
    return new Promise<T>((resolve, reject) => {
      axios(config)
        .catch((error) => {
          // 这一层Catch处理Http的请求异常
          this.handlerError(error);
        })
        .then((res) => {
          if (!this.responseHandler.isSuccess(res)) {
            // 这一层处理业务异常
            this.responseHandler.process(res, ignoreBusinessException, reject);
            return;
          }
          const data = this.responseHandler.getResult<T>(res as AxiosResponse);
          resolve(data);
        });
    });
  }

  private handlerError(error: any) {
    this.httpErrorHandler?.process(error);
  }
}

export default AxiosHttp;
