EXTERN IoDeleteDriver : PROC
     
.CODE
     
DeleteDriverGadget PROC
    jmp IoDeleteDriver
DeleteDriverGadget ENDP
     
END