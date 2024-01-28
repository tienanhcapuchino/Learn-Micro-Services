/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ResponseModel } from '../models/ResponseModel';
import type { UserRegisterModel } from '../models/UserRegisterModel';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class UserService {
    /**
     * @param requestBody
     * @returns ResponseModel Success
     * @throws ApiError
     */
    public static postApiUserRegisterUserRegister(
        requestBody?: UserRegisterModel,
    ): CancelablePromise<ResponseModel> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/User/RegisterUser/register',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
}
