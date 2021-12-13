import { CloudAccount } from '../../models/Cloud';
import AxiosHttp from '../http';

export default class CloudAccountRepository {
    List(): Promise<CloudAccount[]> {
        return AxiosHttp.Instance.get('/CloudAccount/List');
    }
}
