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
  }
};
