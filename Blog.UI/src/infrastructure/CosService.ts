import COS from 'cos-js-sdk-v5';
import CosProviderRepository from './repository/CosProviderRepository';
import { BucketConfig } from '../domain/BucketConfig';
import dayjs from 'dayjs';

class CosService {
    private config: BucketConfig = { bucket: '', region: '' };
    private instance: COS = new COS({
        getAuthorization: async (options, callback) => {
            const data = await new CosProviderRepository().GetCredential();
            callback({
                SecurityToken: data.token,
                TmpSecretId: data.secretId,
                TmpSecretKey: data.secretKey,
                StartTime: data.startTime,
                ExpiredTime: data.expiredTime,
                ScopeLimit: true,
            });
        },
    });
    async multiUpload(files: File[]): Promise<string[]> {
        this.config = await new CosProviderRepository().GetConfig();
        const file = files[0];
        const file_name = `${dayjs().format('YYYY-MM-DD-HH-mm-ss')}-${
            file.name
        }`;
        return new Promise<string[]>((resolve, reject) => {
            this.instance.putObject(
                {
                    Bucket: this.config.bucket,
                    Region: this.config.region,
                    Key: `images/${file_name}`,
                    Body: file,
                },
                (err, data) => {
                    if (err) {
                        reject(err);
                        return;
                    }
                    const name = data.Location.substring(
                        data.Location.lastIndexOf('/') + 1
                    );
                    resolve([`http://1.15.82.132:9004/p/${name}`]);
                }
            );
        });
    }
}

export default new CosService();
