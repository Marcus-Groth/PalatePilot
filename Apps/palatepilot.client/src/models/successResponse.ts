export interface SuccessResponse<T = any> {
  statusCode: number;
  title: string;
  message: string;
  data: T;
}
