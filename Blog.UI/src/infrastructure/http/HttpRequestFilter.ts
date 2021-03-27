import { HttpRequestFilter } from '.';
import { AxiosRequestConfig } from 'axios';

export default class AxiosHttpRequestFilter implements HttpRequestFilter {
  process(config: AxiosRequestConfig): AxiosRequestConfig {
    config.headers = {};
    return config;
  }
}
