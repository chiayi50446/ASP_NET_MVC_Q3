# ASP_NET_MVC_Q3

# 資料的新增，修改，刪除

修改 ASP NET MVC 專案，使用對應的 url 完成資料的瀏覽，新增，修改，刪除

## 基本

- 以 Product.Data 當作資料存取的來源，請勿直接修改 Product.cs 這個檔案

- UI 樣式不拘，可以自己設計或使用其他 css framework

- 瀏覽器輸入 http://{host}/Product/List，使用表格呈現資料集結果，並加入新增、修改、刪除的功能

    - 調整 List 的 UI 呈現
    - 表格只要呈現以下欄位

        - Id - 產品唯一代號，流水號
        - ProductName - 產品名稱
        - Locale - 地區
        - CreateDate - 建立時間，格式為 'yyyy/MM/dd HH:mm:ss'
        - UpdateDate - 資料更新時間，格式為 'yyyy/MM/dd HH:mm:ss'

- 新增資料

    - ProductName - 產品名稱
    - Locale - 地區 (下拉式選單)

- 修改資料

    - ProductName - 產品名稱
    - Locale - 地區 (下拉式選單)

- 刪除資料

    - 刪除指定 Id 的資料

- Locale 對應地區說明

    - US - Unite State
    - DE - Germany
    - CA - Canada
    - ES - Spain
    - FR - France
    - JP - Japan

 
## 改良

- 使用 ViewModel
- 區分 View, Controller, 與 Model 的職責
- 使用 Interface 實作資料存取
