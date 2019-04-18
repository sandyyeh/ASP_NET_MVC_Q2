# ASP_NET_MVC_Q2

# Routing 路由

建立一個 ASP NET MVC 專案，使用對應的 url 完成資料瀏覽

## 基本

- 使用 data.json 為資料來源

- 瀏覽器輸入 http://{host}/Product?page={page}，使用表格呈現指定分頁數 {page} 的資料集結果 (樣式不拘，可以自己設計)

    - 每頁呈現五筆 

    - 表格只要呈現以下欄位

        - Id - 產品唯一代號
        - ProductName - 產品名稱
        - Locale - 地區
        - CreateDate - 建立時間

    - 需要一個分頁 UI (樣式不拘，可以自己設計)

- 瀏覽器輸入 http://{host}/Product/Detail/{id}，呈現該筆 Id 的資料詳細結果 (樣式不拘，可以自己設計)

    - 只要呈現以下欄位

        - ProductName - 產品名稱
        - Locale - 地區
        - Price - 依地區格式化的貨幣字串，若無法轉換則呈現 '-'
        - PromotePrice - 依地區格式化的貨幣字串，若無法轉換則呈現 '-'
        - CreateDate - 建立時間

    - Locale 對應地區說明

        - US - Unite State
        - DE - Germany
        - CA - Canada
        - ES - Spain
        - FR - France
        - JP - Japan

## 改良

- 在 List 頁面可以點擊指定資料列並瀏覽 Detail 頁面 (方式不拘，可以自己設計)
- 分頁 UI 的邏輯判斷
- 使用 ViewModel
- 區分 Controller 與資料存取的職責