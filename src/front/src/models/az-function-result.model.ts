export interface AzFunctionResult<T> {
    value: T;
    statusCode: number;
}