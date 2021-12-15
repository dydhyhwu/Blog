import { AddCosProvider, CosProviderListItem } from '../../models/Cloud';
import AxiosHttp from '../http';

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
}
