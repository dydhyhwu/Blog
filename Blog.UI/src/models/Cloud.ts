export interface CloudAccount {
    id: string;
    name: string;
    appId: string;
    createTime: string;
}

export interface CosProviderListItem {
    id: string;
    accountId: string;
    appId: string;
    bucketName: string;
    region: string;
    allowPrefix: string;
    allowActions: StsClientAction[];
    enable: boolean;
}

export enum StsClientAction {
    // 简单上传
    NormalUpload = 0,

    // 表单、小程序上传
    FormOrMiniUpload = 1,

    // 分块上传
    MultipartUpload = 2,
}

export interface AddCosProvider {
    accountId: string;
    name: string;
    region: string;
    duration: number;
    allowPrefix: string;
    allowActions: StsClientAction[];
}

export class CosProviderDetail {
    id: string;
    accountId: string;
    region: string;
    bucketName: string;
    duration: number;
    allowPrefix: string;
    allowActions: StsClientAction[];
    uploadPrefix: string;
    host: string;
}
