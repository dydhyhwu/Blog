export default interface HttpResponse<T = any> {
    code: ResponseStatus;
    message: string;
    data?: T;
}

export enum ResponseStatus {
    success = 200,
    error = 500,
    noAuthorize = 600,
    authorizeExpired = 601,
    noPermission = 602,
}
