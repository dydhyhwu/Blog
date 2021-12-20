import COS from 'cos-js-sdk-v5';
import CosProviderRepository from './repository/CosProviderRepository';
import { BucketConfig } from '../domain/BucketConfig';
import dayjs from 'dayjs';

class CosService {
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
    async upload(file: File): Promise<string> {
        const {
            bucket,
            region,
            uploadPrefix,
            host,
        } = await new CosProviderRepository().GetConfig();
        const file_key = this.generateFileKey(uploadPrefix, file.name);
        return new Promise<string>((resolve, reject) => {
            this.instance.putObject(
                {
                    Bucket: bucket,
                    Region: region,
                    Key: file_key,
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
                    const url = this.generateUrl(name, host);
                    resolve(url);
                }
            );
        });
    }

    private generateFileKey(prefix: string, name: string): string {
        const datetime = dayjs().format('YYYY-MM-DD-HH-mm-ss');
        const file_name = `${datetime}-${name}`;
        const split_char = prefix.endsWith('/') ? '' : '/';
        return `${prefix}${split_char}${file_name}`;
    }

    private generateUrl(name: string, host: string): string {
        const split_chat = host.endsWith('/') ? '' : '/';
        return `${host}${split_chat}${name}`;
    }
}

export default new CosService();
