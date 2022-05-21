package model;

public class ResultDTO {

	
	
	private String formula;
	private String result;
	
	public ResultDTO(String formula, String result) {
		
		this.formula = formula;
		this.result =result;
	}
	 public String getFormula()
     {
        return this.formula;
     }
	  
	  public void setFormula(String formula)
     {
        this.formula = formula;
     }
	  
	  
	  public String getResult()
     {
        return this.result;
     }
	  
	  public void  getResult(String result)
     {
        this.result = result;
     }
	  
	 
	
}
