import {
    AddCosProvider,
    CosProviderDetail,
    CosProviderListItem,
} from '../../models/Cloud';
import AxiosHttp from '../http';
import { Credential } from '../../domain/Credential';
import { BucketConfig } from '../../domain/BucketConfig';

export default class CosProviderRepository {
    async List(): Promise<CosProviderListItem[]> {
        return AxiosHttp.Instance.post('/CloudProvider/List', {});
    }

    async Add(data: AddCosProvider): Promise<void> {
        return AxiosHttp.Instance.post('/CloudProvider/Add', data);
    }

    async Remove(id: string): Promise<void> {
        const data = {
            id: id,
        };
        return AxiosHttp.Instance.post('/CloudProvider/Delete', data);
    }

    async SetEnable(id: string): Promise<void> {
        return AxiosHttp.Instance.post(`/CloudProvider/Enable?id=${id}`, {});
    }

    async GetCredential(): Promise<Credential> {
        return AxiosHttp.Instance.post('/CloudProvider/GetCredential', {});
    }

    async GetConfig(): Promise<BucketConfig> {
        return AxiosHttp.Instance.get('/CloudProvider/GetConfig');
    }

    async Detail(id: string): Promise<CosProviderDetail> {
        const param = {
            id: id,
        };
        return AxiosHttp.Instance.get('/CloudProvider/Detail', param);
    }

    async Edit(item: CosProviderDetail): Promise<void> {
        return AxiosHttp.Instance.post('/CloudProvider/Edit', item);
    }
}
