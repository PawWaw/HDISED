
#include "cuda_runtime.h"
#include "device_launch_parameters.h"

#include <stdio.h>
#include <fstream>
#include <iostream>
#include <string>
#include <chrono>
#define ARRAYSIZE 1000;
using namespace std;

cudaError_t addWithCuda(int *c, const int *a, const int *b, unsigned int size);

__global__ void addKernel(int *c, const int *a, const int *b)
{
	int i = blockIdx.x*blockDim.x + threadIdx.x;
	c[i] = a[i] * b[i] + 365;
}

// Helper function for using CUDA to add vectors in parallel.
cudaError_t addWithCuda(int *c, const int *a, const int *b, unsigned int size)
{
	int *dev_a = 0;
	int *dev_b = 0;
	int *dev_c = 0;
	cudaError_t cudaStatus;

	// Choose which GPU to run on, change this on a multi-GPU system.
	cudaStatus = cudaSetDevice(0);
	if (cudaStatus != cudaSuccess) {
		fprintf(stderr, "cudaSetDevice failed!  Do you have a CUDA-capable GPU installed?");
		goto Error;
	}

	// Allocate GPU buffers for three vectors (two input, one output)    .
	cudaStatus = cudaMalloc((void**)&dev_c, size * sizeof(int));
	if (cudaStatus != cudaSuccess) {
		fprintf(stderr, "cudaMalloc failed!");
		goto Error;
	}

	cudaStatus = cudaMalloc((void**)&dev_a, size * sizeof(int));
	if (cudaStatus != cudaSuccess) {
		fprintf(stderr, "cudaMalloc failed!");
		goto Error;
	}

	cudaStatus = cudaMalloc((void**)&dev_b, size * sizeof(int));
	if (cudaStatus != cudaSuccess) {
		fprintf(stderr, "cudaMalloc failed!");
		goto Error;
	}

	// Copy input vectors from host memory to GPU buffers.
	cudaStatus = cudaMemcpy(dev_a, a, size * sizeof(int), cudaMemcpyHostToDevice);
	if (cudaStatus != cudaSuccess) {
		fprintf(stderr, "cudaMemcpy failed!");
		goto Error;
	}

	cudaStatus = cudaMemcpy(dev_b, b, size * sizeof(int), cudaMemcpyHostToDevice);
	if (cudaStatus != cudaSuccess) {
		fprintf(stderr, "cudaMemcpy failed!");
		goto Error;
	}

	// Launch a kernel on the GPU with one thread for each element.
	addKernel<<<1, size>>>(dev_c, dev_a, dev_b);

	// Check for any errors launching the kernel
	cudaStatus = cudaGetLastError();
	if (cudaStatus != cudaSuccess) {
		fprintf(stderr, "addKernel launch failed: %s\n", cudaGetErrorString(cudaStatus));
		goto Error;
	}

	// cudaDeviceSynchronize waits for the kernel to finish, and returns
	// any errors encountered during the launch.
	cudaStatus = cudaDeviceSynchronize();
	if (cudaStatus != cudaSuccess) {
		fprintf(stderr, "cudaDeviceSynchronize returned error code %d after launching addKernel!\n", cudaStatus);
		goto Error;
	}

	// Copy output vector from GPU buffer to host memory.
	cudaStatus = cudaMemcpy(c, dev_c, size * sizeof(int), cudaMemcpyDeviceToHost);
	if (cudaStatus != cudaSuccess) {
		fprintf(stderr, "cudaMemcpy failed!");
		goto Error;
	}

Error:
	cudaFree(dev_c);
	cudaFree(dev_a);
	cudaFree(dev_b);

	return cudaStatus;
}

int main()
{
	const int arraySize = ARRAYSIZE;
	int a[arraySize];
	int b[arraySize];
	int c[arraySize];
	int d[arraySize];
	cudaError_t cudaStatus;
	string line, line1, line2, line3, line4, line5;
	string lineRest;
	int counter = 1;
	ifstream myfile("C:/Users/pawel/Desktop/MyTest.txt");

	while (myfile) 
	{
		while (getline(myfile, line) && counter < 1000) 
		{
			line1 = line.substr(0, line.find_first_of(","));
			lineRest = line.substr(line.find(",") + 1);
			line2 = lineRest.substr(0, lineRest.find_first_of(","));
			//lineRest = lineRest.substr(lineRest.find(",") + 1);
			//line3 = lineRest.substr(0, lineRest.find_first_of(","));
			//lineRest = lineRest.substr(lineRest.find(",") + 1);
			//line4 = lineRest.substr(0, lineRest.find_first_of(","));
			//lineRest = lineRest.substr(lineRest.find(",") + 1);
			//line5 = lineRest;
			a[counter - 1] = stoi(line1);
			b[counter - 1] = stoi(line2);
			counter++;
		}
		myfile.close();
	}

	//parrallel time count
	auto start = chrono::duration_cast<chrono::milliseconds>(chrono::system_clock::now().time_since_epoch());
	// add in parallel

	//for(int j = 0; j < 50; j++)
		cudaStatus = addWithCuda(d, a, b, arraySize);

	//if (cudaStatus != cudaSuccess) {
	//	fprintf(stderr, "addWithCuda failed!");
	//	return 1;
	//}

	auto stop = chrono::duration_cast<chrono::milliseconds>(chrono::system_clock::now().time_since_epoch());
	printf("Parallel: %d milliseconds\n\n", stop - start);

	auto start2 = chrono::duration_cast<chrono::milliseconds>(chrono::system_clock::now().time_since_epoch());
	for (int i = 0; i < arraySize; i++)
	{
		c[i] = a[i] * b[i] + 365;
	}
	auto stop2 = chrono::duration_cast<chrono::milliseconds>(chrono::system_clock::now().time_since_epoch());
	printf("Sequential: %d milliseconds\n\n", stop2 - start2);

	//for (int i = 0; i < arraySize; i++)
	//	printf("%d\n", b[i]);

	// cudaDeviceReset must be called before exiting in order for profiling and
	// tracing tools such as Nsight and Visual Profiler to show complete traces.
	cudaStatus = cudaDeviceReset();
	if (cudaStatus != cudaSuccess) {
		fprintf(stderr, "cudaDeviceReset failed!");
		return 1;
	}

	return 0;
}