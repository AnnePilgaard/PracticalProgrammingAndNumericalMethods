public class genlist<T>{
	public T[] data;
	public int size=0;
	public int capacity=8;
	public genlist(){ data = new T[capacity]; }
	public void push(T item){ /* add item to list */
		if(size==capacity){
			T[] newdata = new T[capacity*=2];
			for(int i=0;i<size;i++)newdata[i]=data[i];
			data=newdata;
			}
		data[size]=item;
		size++;
	}
	public void remove(int i){
		if (i==size-1){
			size--;
			return;
		}
		for (int j=i; j<size-1;j++){
			data[j] = data[j+1];
		}
		size--;
		
	}
}