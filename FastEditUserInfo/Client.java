package FastEditUserInfo;

public class Client {
    private String clientNum;
    private String docNum;
    private Integer ActiveYears;

    public Client(String clientNum, String docNum, Integer activeYears) {
        this.clientNum = clientNum;
        this.docNum = docNum;
        ActiveYears = activeYears;
    }

    public void setClientNum(String clientNum) {
        this.clientNum = clientNum;
    }

    public void setDocNum(String docNum) {
        this.docNum = docNum;
    }

    public void setActiveYears(Integer activeYears) {
        ActiveYears = activeYears;
    }

    public String getClientNum() {
        return clientNum;
    }

    public String getDocNum() {
        return docNum;
    }

    public Integer getActiveYears() {
        return ActiveYears;
    }
}
