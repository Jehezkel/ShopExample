import axios from "axios";
const apiClient = axios.create({
  baseURL: window.location.origin + "/api",
  headers: {
    Accept: "application/json",
    "Content-Type": "application/json"
  },
  timeout: 10000
});
export default {
  getProducts() {
    return apiClient.get("products");
  },
  postImage(data, statusDto, updateStatusFunc) {
    var formData = new FormData();
    formData.append("uploadedImage", data);
    let imgClient = axios.create({
      baseURL: window.location.origin + "/api",
      headers: {
        "Content-Type": "multipart/form-data"
      },
      timeout: 100000000
    });
    imgClient
      .post("images", formData, {
        onUploadProgress: progress => {
          statusDto.loadPercent = Math.round(
            100 * (progress.loaded / progress.total)
          );

          updateStatusFunc(statusDto);
        }
      })
      .then(response => {
        statusDto.fullFilePath = response.data.fullFilePath;
        statusDto.ProductImageId = response.data.productImageId;
        updateStatusFunc(statusDto);
      });
  },
  createProduct(data) {
    return apiClient.post("products", data);
  },
  getProductDetail(productId) {
    return apiClient.get("products/" + productId);
  }
};
