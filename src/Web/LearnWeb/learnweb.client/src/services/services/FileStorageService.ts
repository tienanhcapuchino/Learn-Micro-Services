/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ResponseModel } from '../models/ResponseModel';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class FileStorageService {
    /**
     * @param bucketName
     * @returns ResponseModel Success
     * @throws ApiError
     */
    public static postApiFileStorageCreateBucketCreateBucket(
        bucketName?: string,
    ): CancelablePromise<ResponseModel> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/FileStorage/CreateBucket/create/bucket',
            query: {
                'bucketName': bucketName,
            },
        });
    }
}
