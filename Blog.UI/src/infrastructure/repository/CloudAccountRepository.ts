import { CloudAccount } from '../../models/Cloud';
import AxiosHttp from '../http';

export default class CloudAccountRepository {
    List(): Promise<CloudAccount[]> {
        return AxiosHttp.Instance.get('/CloudAccount/List');
    }

    async Add(data: {
        secretKey: string;
        appId: string;
        name: string;
        secretId: string;
    }): Promise<void> {
        return AxiosHttp.Instance.post('/CloudAccount/Add', data);
    }

    async Remove(id: string): Promise<void> {
        const param = {
            id: id,
        };
        return AxiosHttp.Instance.post('/CloudAccount/Delete', param);
    }
}
